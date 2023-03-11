// See https://aka.ms/new-console-template for more information

using ConsoleTest;

var sampleProductList = new List<ProductItem>();
var counter = 0;

for (var i = 0; i < 1000; i++)
{
    var sampleProduct = new ProductItem();
    sampleProduct.IsActive = true;
    sampleProduct.Name = "Product number " + counter.ToString();
    counter++;
    sampleProductList.Add(sampleProduct);
}

var testAPIService = new TestAPIService();

Console.WriteLine("Insertando productos no async a las " + DateTime.Now.ToString());

for (var i = 0; i < 200; i++)
{
    testAPIService.CallPostProduct("https://localhost:7201/product/post", sampleProductList);
}

Console.WriteLine("Fin insertados productos no async a las " + DateTime.Now.ToString());

Console.WriteLine("Insertando productos async a las " + DateTime.Now.ToString());

for (var i = 0; i < 200; i++)
{
    testAPIService.CallPostProduct("https://localhost:7201/product/postassyynnc", sampleProductList);
}

Console.WriteLine("Fin insertados productos async a las " + DateTime.Now.ToString());