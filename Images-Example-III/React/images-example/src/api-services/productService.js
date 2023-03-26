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

    async getProductsBase64Array() {
        let response = await apiClient.get("/Product/GetAllBase64List");
        if (!response == 200) {
            alert("Upsi, hubo un error al traer los productos.")
        };
        let allProducts = response.data;
        return allProducts;
    },

    async submitProductImgBase64(newProductBase64RequestModel) {
        let response = await apiClient.post("/Product/PostBase64", newProductBase64RequestModel)
        if (response.status == 200) {
            alert("Producto insertado correctamente con id " + response.data);
        } else {
            alert("Upsi...hubo un error al insertar el producto");
        }
    },

    async getProductsFileArray() {
        // let response = await apiClient.get("/Product/GetAllBase64List");
        // if (!response == 200) {
        //     alert("Upsi, hubo un error al traer los productos.")
        // };
        // let allProducts = response.data;
        // return allProducts;
    },

    async submitProductFile(newProductFileRequestModel) {
        const config = {
            headers: {
                "Content-Type": "multipart/form-data"
            },
        };
        var newProductFileRequest = new FormData();
        newProductFileRequest.append("file", newProductFileRequestModel.file);
        newProductFileRequest.append("stringProductData", JSON.stringify(newProductFileRequestModel.productData));
        let response = await apiClient.post("/Product/PostProductFile", newProductFileRequest, config);
        if (response.status == 200) {
            alert("Producto insertado correctamente con id " + response.data);
        } else {
            alert("Upsi...hubo un error al insertar el producto");
        }
    }

}