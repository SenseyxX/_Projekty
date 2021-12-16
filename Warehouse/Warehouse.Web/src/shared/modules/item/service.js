import client from "@/shared/http-client";
import { ItemFullDto } from "@/shared/modules/item/dto";

const  service = {
    async getItem(id) {
        const resource = `item/${Id}`;
        const response = await client.get(resource);
        return new  ItemDto(response.data);
    },    
    async addItem(command){
        const resource = "squad"
        return await client.post(resource,command)  
    },
};

export default service;