import { productService } from "../api-services/productService";

export const productHandler = {

    async addProductImgBase64(newProductBaseModel) {
        
        if (!newProductBaseModel) {
            return;
        }

        let imgStringData = newProductBaseModel.imgBase64;
        let imgStringDataSplit = imgStringData.split(',');
        let imgContent = imgStringDataSplit[1];
        let imgExtension = imgStringDataSplit[0].split(';')[0].split(':')[1];

        let newProductBase64RequestModel = {
            "productData": {
                "title": newProductBaseModel.title,
                "price": newProductBaseModel.price
            },
            "base64FileModel": {
                "fileName": newProductBaseModel.title + "-Photo",
                "base64FileContent": imgContent,
                "extension": imgExtension
            }
        }

        return await productService.submitProductImgBase64(newProductBase64RequestModel);

    },

    async loadProductsBas64Array() {

        return await productService.getProductsBase64Array();

    },

    async addProductImgFile(newProductBaseModel) {
        
        if (!newProductBaseModel) {
            return;
        }

        let newProductFileRequestModel = {
            "productData": {
                "title": newProductBaseModel.title,
                "price": newProductBaseModel.price
            },
            "file": newProductBaseModel.imgFile
        }

        return await productService.submitProductFile(newProductFileRequestModel);

    }

}