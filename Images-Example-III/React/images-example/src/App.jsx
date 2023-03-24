import { useState } from 'react'
import './App.css'
import { productHandler } from './handlers/productHandler.js'
import Images from './Images';

function App() {

  const [title, setTitle] = useState("");
  const [price, setPrice] = useState(0);
  const [img, setImg] = useState(null);

  const handleTitleChange = (event) => {
    setTitle(event.target.value);
  };
  const handlePriceChange = (event) => {
    setPrice(event.target.value);
  };
  const handleImgChange = (event) => {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      setImg(reader.result)
    };
  }

  const handleSubmit = (event) => {
    event.preventDefault();
    let newProduct = { title, price, img };
    productHandler.addProduct(newProduct);
    event.target.reset()
  };

  var images = null;

  function loadImages(){
    images = productHandler.loadProducts();
  }

  return (
    <div className="App">
      <form onSubmit={handleSubmit} itemID="form1">
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
          <input name="img" type="file" className="form-control" placeholder="Upload a picture" onChange={handleImgChange} required />
        </div>

        <button type="submit" className="btn btn-primary" id="btn">Upload</button>
      </form>

      <Images/>
        
    </div>
    
  )
}

export default App;