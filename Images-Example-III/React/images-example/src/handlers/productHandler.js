import { productService } from "../api-services/productService";

export const productHandler = {
    addProduct(newProduct) {
        if (!newProduct) {
            return;
        }

        let imgStringData = newProduct.img;
        let imgStringDataSplit = imgStringData.split(',');
        let imgContent = imgStringDataSplit[1];
        //pendiente ver con qué splits o regex obtener el tipo de archivo (jpg, pgn, lo que sea)

        //ASÍ SE ENVIARÍA SI FUERA UN SOLO OBJETO COMPLETO Y ENTERO
        let newProductRequestModel = {
            "productData": {
                "title": newProduct.title,
                "price": newProduct.price
            },
            "fileData": {
                "fileName": newProduct.title + "-Photo",
                "base64FileContent": imgContent
            }
        }
        //RESUMEN, FUNCIONA!

        //ASÍ LO ENVIAMOS COMO UN MULTIPART DE OBJETOS SEPARADOS POR EL BÁCULO DE GANDALF
        //DE MORIA CUAL BALROG EN LAS MINAS
        // let productData = {
        //     "title": newProduct.title,
        //     "price": newProduct.price
        // };
        // let fileData = {
        //     "fileName": newProduct.title + "-Photo",
        //     "base64FileContent": imgContent
        // };
        // let newProductMPFD = new FormData();
        // newProductMPFD.append("productData", productData);
        // newProductMPFD.append("fileData", fileData);
        //RESUMEN, LOS DATOS LLEGAN NULOS, REVEER CÓMO SE ARMA ASÍ

        return productService.submitProduct(newProductRequestModel);

    },

    async loadProducts() {
        var result = await productService.getProducts();
        return result;
    },
    
}