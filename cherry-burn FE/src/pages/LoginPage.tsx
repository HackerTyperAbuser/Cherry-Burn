import { LoginForm } from "../components/Auth/LoginForm";

export default function LoginPage() {
    return (
       <>
       <div className="min-h-screen flex">
            {/* Left Column */}
            <div className="w-full md:w-1/2 flex flex-col justify-center items-center p-8 bg-white min-h-screen">
                <div className="w-full max-w-md text-center">
                    <h1 className="text-3xl font-bold font-hanuman mb-10">
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
            <div className="hidden md:block w-1/2 bg-[#D9D9D9] h-screen">
                <img
                    src="https://kenh14cdn.com/203336854389633024/2025/6/3/48283131412191260697843997057666022932740617n-1-1748850385797883379372-1748857663886-1748857664041718719517-1748910698569-17489106994471315547287.jpg"
                    alt="Login visual"
                    className="w-full h-full object-cover"
                />
            </div>
       </div>
        </>
    )
}