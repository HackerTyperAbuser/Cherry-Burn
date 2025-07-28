import type { Dispatch, SetStateAction } from 'react';
import { FaEye, FaEyeSlash } from 'react-icons/fa';

interface EyeToggleProps
{
    showPassword: boolean;
    setShowPassword: Dispatch<SetStateAction<boolean>>;
}
export function EyeToggle({showPassword, setShowPassword} : EyeToggleProps) 
{
    return (
        <>
        <button 
            type="button"
            onClick={() => setShowPassword(!showPassword)}
            className="absolute inset-y-0 right-4 flex items-center text-gray-600 hover:text-black">
                {showPassword ? <FaEyeSlash /> : <FaEye />}
        </button>
        </>
    )
}