import axios from "../../services/axiosInstance"

export async function loginUser(username: string, password: string) {
    const response = await axios.post("/api/auth/login", { username, password });
    return response.data;
}