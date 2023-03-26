import { productHandler } from './handlers/productHandler.js'
import { useState } from 'react'

function Images() {

    let [imgsBase64Array, setImgsBase64Array] = useState([]);

    async function onChangeImgsBase64Array() {
        let loadedBase64Imgs = await productHandler.loadProductsBas64Array();
        setImgsBase64Array(loadedBase64Imgs);
    }

    function buildImgSrc(extension, content) {
        return "data:" + extension + ";base64," + content;
    }

    if (imgsBase64Array.length > 0) {

        return (
            <div>
                <button className="btn btn-primary" id="btn" onClick={onChangeImgsBase64Array}>CargarImagenes desde lista en Base64</button>
                {imgsBase64Array.map(img => (
                    <img key={imgsBase64Array.indexOf(img)} src={buildImgSrc(img.extension, img.base64FileContent)} alt="sasasa" min-width="1000" min-height="1000" />
                ))}

            </div>
        )

    } else {

        return (
            <div>
                <button className="btn btn-primary" id="btn" onClick={onChangeImgsBase64Array}>CargarImagenes</button>
                <div>
                    No hay orcos en la costa.
                </div>
            </div>
        )
    }

}

export default Images;