import { productHandler } from './handlers/productHandler.js'
import { useState } from 'react'

function Images() {

    let [imagesArray, setImagesArray] = useState([]);

    async function onChangeImagesArray() {
        let loadedProducts = await productHandler.loadProducts();
        setImagesArray(loadedProducts);
    }

    function buildImgSrc(content) {
        return "data:image/png;base64," + content;
    }
    if (imagesArray != undefined && imagesArray != null && imagesArray.length > 0) {
        return (
            <div>
                <button className="btn btn-primary" id="btn" onClick={onChangeImagesArray}>CargarImagenes</button>
                {imagesArray.map(img => (
                    <img src={buildImgSrc(img.content)} alt="sasasa" min-width="1000" min-height="1000" />
                ))}

            </div>

        )
    } else {
        return (
            <div>
                <button className="btn btn-primary" id="btn" onClick={onChangeImagesArray}>CargarImagenes</button>
                <div>
                    No hay orcos en la costa.
                </div>
            </div>
        )
    }

}

export default Images;

        //     {imagesArray.map(img => (
        //         <img src={buildImgSrc(img.base64FileContent)} alt="sasasa" width="100" height="100">
        // ))}