import { productService } from "../api-services/productService";
import JSZip from 'jszip';

export const productHandler = {

    async addProductImgBase64(newProductBaseModel) {

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

    async loadProductsBase64Array() {

        return await productService.getProductsBase64Array();

    },

    async addProductImgFile(newProductBaseModel) {

        let newProductFileRequestModel = {
            "productData": {
                "title": newProductBaseModel.title,
                "price": newProductBaseModel.price
            },
            "file": newProductBaseModel.imgFile
        }

        return await productService.submitProductFile(newProductFileRequestModel);

    },

    async loadProductsFilesArray() {

        var filesZip = await productService.getProductsFilesZip();
        const zip = new JSZip();
        const extractedZip = await zip.loadAsync(filesZip);
        const filesList = [];
        for(var item of Object.entries(extractedZip.files)) {
            var fileItem = await zip.file(item[0]).async('blob');
            var newBlob = new Blob([fileItem], { type: this.getFileContentType(item[0].split('.')[1]) });
            filesList.push(newBlob);
        }
        return filesList;

    },

    getFileContentType(extension){
    
        const contentTypes = {
            png: "image/png",
            jpeg: "image/jpeg",
            jpg: "image/jpg"
        }

        try{
            if(contentTypes[extension].length > 0){
                return contentTypes[extension];
            }
        }catch{
            return "application/octet-stream";
        }

    }

}