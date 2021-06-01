import axios from "./AxiosClient";

export async function getChats(storage) {
    return await axios
        .get('/ChatsList',
            {
                params: { userId: storage.profile.sub },
                headers: { 'Authorization': `Bearer ${storage.access_token}` }
            })
        .then((res) => res.data);
}
