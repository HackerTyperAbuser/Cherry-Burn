import { LoginForm } from "../components/Auth/LoginForm";

export default function LoginPage() {
    return (
       <>
       <div className="min-h-screen flex">
            {/* Left Column */}
            <div className="w-full md:w-1/2 flex flex-col justify-center items-center p-8 bg-white min-h-screen">
                <div className="w-full max-w-md text-center">
                    <h1 className="text-3xl font-bold font-hanuman mb-20">
                    Welcome back!
                    </h1>
                    <p className="text-lg font-medium">Please enter your details</p>
                </div>
                <div className="w-full max-w-md mb-6">
                    {/* LoginForm */}
                    <LoginForm />

                </div>
            </div>
            {/* Right Column */}
            <div className="hidden md:block w-1/2 m-8 bg-[#D9D9D9] rounded-lg"></div>
       </div>
        </>
    )
}