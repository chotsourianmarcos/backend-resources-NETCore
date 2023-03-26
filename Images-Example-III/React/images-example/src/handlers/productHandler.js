import { productService } from "../api-services/productService";

export const productHandler = {

    addProductImgBase64(newProduct) {
        
        if (!newProduct) {
            return;
        }

        let imgStringData = newProduct.imgBase64;
        let imgStringDataSplit = imgStringData.split(',');
        let imgContent = imgStringDataSplit[1];
        let imgExtension = imgStringDataSplit[0].split(';')[0].split(':')[1];

        let newProductBase64RequestModel = {
            "productData": {
                "title": newProduct.title,
                "price": newProduct.price
            },
            "base64FileModel": {
                "fileName": newProduct.title + "-Photo",
                "base64FileContent": imgContent,
                "extension": imgExtension
            }
        }

        return productService.submitProductImgBase64(newProductBase64RequestModel);

    },

    async loadProductsBas64Array() {

        var result = await productService.getProductsBase64Array();
        return result;

    },

}