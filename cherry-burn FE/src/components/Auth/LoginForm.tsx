import { useEffect, useState } from "react"
import { Link } from "react-router-dom"
import { loginUser } from "../../features/auth/api";

export function LoginForm() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    useEffect(() => {
        if (error) {
            
            const timer = setTimeout(() => {
                setError("");
            }, 3000);
            return () => clearTimeout(timer);
        }
    }, [error]);

    async function handleSubmit(e: React.FormEvent) {
        e.preventDefault();

        if (!username || !password) {
            setError("Please enter both username and password.");
            return;
        }

        try
        {
            const data = await loginUser(username, password);
            localStorage.setItem("token", data.token);
            setError("");
        }
        catch (err) {
            console.error("Login failed", err);
            setError("Login failed. Please check your credentials.");
        }
    }

    return (
        <>
        <form onSubmit={handleSubmit} className="w-full space-y-6 mt-8 text-base">
            <button
                type="button"
                className="w-full cursor-pointer accent-black border border-gray-300 rounded-full py-3 px-6 text-base hover:bg-gray-100 transition">
                Login with Google
            </button>

            <div className="flex items-center">
                <hr className="flex-grow border-gray-300" />
                <span className="mx-4 text-gray-400 text-base">Or</span>
                <hr className="flex-grow border-gray-300" />
            </div>
            
            {/* Username */}
            <input 
                className="w-full border text-base accent-black border-gray-300 rounded-full focus:outline-non focus:ring-black focus:ring-2 py-3 px-5"
                type="text" 
                placeholder="Username" 
                value={username} 
                onChange={(e) => setUsername(e.target.value)}/>

            {/* Password */}
            <input 
                className="w-full border text-base accent-black border-gray-300 rounded-full focus:outline-non focus:ring-black focus:ring-2 py-3 px-5"
                type="password" 
                placeholder="Password" 
                value={password} 
                onChange={(e) => setPassword(e.target.value)}/>
            
            {/* Error message */}
            <div className="mt-1 ml-2 min-h-[20px]">
                <p className={`text-red-700 text-sm transition-opacity ease-in-out ${ error ? "opacity-100 duration-0" : "opacity-0 duration-700"}`}>{error}</p>
            </div>

            {/* Remember Checkbox */}
            <div className="flex items-center space-x-2 text-base">
                <input 
                    type="checkbox" 
                    id="remember" 
                    className="w-5 h-5 rounded-sm accent-black text-white border border-black focus:ring-black transition"/>
                <label 
                    htmlFor="remember" 
                    className="text-gray-700">
                        Remember for 30 days
                </label>
            </div>

            {/* Submit Button */}
            <button className="w-full accent-black cursor-pointer text-white py-3 px-6 rounded-full bg-black hover:bg-gray-800 transition border-black border text-lg focus:ring-black">
                Login
            </button>

            {/* Link to Register */}
            <p className="text-center text-base text-gray-600">
                Don't have an account? {""}
                <Link to="/register" className="text-black accent-black hover:text-gray-800 hover:underline">
                Signup</Link>
            </p>
        </form>
        </>
    )
}