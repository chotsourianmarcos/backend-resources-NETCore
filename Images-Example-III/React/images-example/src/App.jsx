import { useState } from 'react'
import './App.css'
import { productHandler } from './handlers/productHandler.js'
import Images from './Images';

function App() {

  const [title, setTitle] = useState("");
  const [price, setPrice] = useState(0);

  const [imgBase64, setImgBase64] = useState(null);
  const [imgFile, setImgFile] = useState(null);

  const handleTitleChange = (event) => {
    setTitle(event.target.value);
  };
  const handlePriceChange = (event) => {
    setPrice(event.target.value);
  };

  const handleImgBase64Change = (event) => {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      setImgBase64(reader.result)
    };
  }
  const handleSubmitBase64 = (event) => {
    event.preventDefault();
    let newProductBase64RequestModel = { title, price, imgBase64 };
    productHandler.addProductImgBase64(newProductBase64RequestModel);
  };

  const handleImgFileChange = (event) => {
    const file = event.target.files[0];
    setImgFile(file);
  }
  const handleSubmitFile = (event) => {
    event.preventDefault();
    let newProductFileRequestModel = { title, price, imgFile };
    productHandler.addProductImgFile(newProductFileRequestModel);
  };

  return (
    <div className="App">

      <form itemID="form1">

        <h1>Create a new product</h1>

        <div className="mb-3">
          <label htmlFor="title" className="form-label">Title</label>
          <input name="title" type="text" className="form-control" placeholder="Product name" onChange={handleTitleChange} required />
        </div>

        <div className="mb-3">
          <label htmlFor="price" className="form-label">Price</label>
          <input name="price" type="number" min="1" className="form-control" placeholder="How much does it cost?" onChange={handlePriceChange} required />
        </div>

        <div className="mb-3">
          <label htmlFor="imgBase64" className="form-label">Image Base 64</label>
          <input name="imgBase64" type="file" className="form-control" placeholder="Upload a picture" onChange={handleImgBase64Change} required />
        </div>
        <button onClick={handleSubmitBase64} className="btn btn-primary" id="btn">Upload con img en Base 64</button>

        <div className="mb-3">
          <label htmlFor="imgFile" className="form-label">Image File</label>
          <input name="imgFile" type="file" className="form-control" placeholder="Upload a picture" onChange={handleImgFileChange} required />
        </div>
        <button onClick={handleSubmitFile} className="btn btn-primary" id="btn">Upload con img file</button>

      </form >

      <Images />

    </div >

  )
}

export default App;