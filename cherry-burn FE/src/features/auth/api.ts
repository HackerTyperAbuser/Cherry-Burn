import axios from "../../services/axiosInstance"

export async function loginUser(email: string, password: string) {
    const response = await axios.post("/api/users/login", { email, password });
    return response.data;
}