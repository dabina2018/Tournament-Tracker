//import Papa from 'papaparse';
import CreatePrize from "./CreatePrize.js";

const tableRoot = document.querySelector("#csvRoot");  //table Id from index file
const csvFileInput = document.querySelector("#csvFileInput");
const createPrize = new CreatePrize(tableRoot);

csvFileInput.addEventListener("change", e => {
    console.log(csvFileInput.files[0]);

    Papa.parse(csvFileInput.files[0], {
        delimiter: ",",
        skipEmptyLines: true,
        complete: results =>{
            createPrize.update(results.data.slice(1), results.data[0]);
        }
    })
});

/*
createPrize.update([
    [1, "positive", 99, "$100"],
    [2, "broke even", 99, 8908],
    [3, "negative", 99, "$400"]
], ["ID", "Revenue", "Profit", "Cost"])
*/
