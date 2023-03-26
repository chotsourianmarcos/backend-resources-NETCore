import { useState } from 'react'
import './App.css'
import { productHandler } from './handlers/productHandler.js'
import Images from './Images';

function App() {

  const [title, setTitle] = useState("");
  const [price, setPrice] = useState(0);

  const [imgBase64, setImgBase64] = useState(null);

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
    let newProductRequestModel = { title, price, imgBase64 };
    productHandler.addProductImgBase64(newProductRequestModel);
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
          <label htmlFor="img" className="form-label">Image</label>
          <input name="imgBase64" type="file" className="form-control" placeholder="Upload a picture" onChange={handleImgBase64Change} required />
        </div>
        <button onClick={handleSubmitBase64} className="btn btn-primary" id="btn">Upload con img en Base 64</button>

      </form>

      <Images />

    </div>

  )
}

export default App;