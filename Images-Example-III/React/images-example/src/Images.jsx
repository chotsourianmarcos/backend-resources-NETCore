import { productHandler } from './handlers/productHandler.js'
import { useState } from 'react'

function Images() {

    let [imgsBase64Array, setImgsBase64Array] = useState([]);
    let [imgsBase64FromFilesArray, setImgsBase64FromFilesArray] = useState([]);

    async function loadImgsBase64Array() {
        let loadedBase64Imgs = await productHandler.loadProductsBase64Array();
        setImgsBase64Array(loadedBase64Imgs);
    }
    function buildImgSrcFromBase64Model(extension, content) {
        return "data:" + extension + ";base64," + content;
    }

    async function loadImgsFilesArray() {
        let loadedFilesImgs = await productHandler.loadProductsFilesArray();
        var builtList = await buildImgsSrcFromFileList(loadedFilesImgs);
        setImgsBase64FromFilesArray(builtList);
    }
    async function buildImgsSrcFromFileList (list){
        var resultList = [];
        for(var i = 0; i < list.length; i++){
            var builtItem = await buildImgSrcFromFile(list[i]);
            resultList.push(builtItem);
        }
        return resultList;
    }
    async function buildImgSrcFromFile(file) {
        return await new Promise((resolve) => {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = async () => {
                const response = reader.result;
                resolve(response);
            }
        });
    }

    if (imgsBase64Array.length > 0 || imgsBase64FromFilesArray.length > 0) {

        return (
            <div>
                <button className="btn btn-primary" id="btn" onClick={loadImgsBase64Array}>CargarImagenes desde lista en Base64</button>
                {imgsBase64Array.map(img => (
                    <img key={imgsBase64Array.indexOf(img)} src={buildImgSrcFromBase64Model(img.extension, img.base64FileContent)} alt="sasasa" min-width="1000" min-height="1000" />
                ))}
                <button className="btn btn-primary" id="btn" onClick={loadImgsFilesArray}>CargarImagenes desde lista de archivos</button>
                {imgsBase64FromFilesArray.map(img => (
                    <img key={imgsBase64FromFilesArray.indexOf(img)} src={img} alt="sasasa" min-width="1000" min-height="1000" />
                ))}

            </div>
        )

    } else {

        return (
            <div>
                <button className="btn btn-primary" id="btn" onClick={loadImgsBase64Array}>CargarImagenes desde lista en base64</button>
                <button className="btn btn-primary" id="btn" onClick={loadImgsFilesArray}>CargarImagenes desde lista de archivos</button>
                <div>
                    No hay orcos en la costa.
                </div>
            </div>
        )

    }
}

export default Images;