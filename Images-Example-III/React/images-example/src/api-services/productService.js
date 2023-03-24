import axios from "axios";

const apiClient = axios.create({
    baseURL: 'https://localhost:7277',
    withCredentials: false,
    headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json'   
    }
})

export const productService = {
    async getProducts() {
        let response = await apiClient.get("/Product/GetAllFilesList");
        if (!response==200)
            {
                alert("Upsi, hubo un error al traer los productos.")
            };
        let allProducts = response.data;
        console.log(allProducts);
        return allProducts;
    },
    async submitProduct(newProductRequestModel){
        // var paramus = {
        //     content: newProductMPFD
        // };
        let response = await apiClient.post("/Product/PostProductGandalfizado", newProductRequestModel)
        if (response.status == 200) 
        { 
            alert("Producto insertado correctamente con id " + response.data);   
        }else{
            alert("Upsi...");
        }
    }
}