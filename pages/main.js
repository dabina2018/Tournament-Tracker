//import Papa from 'papaparse';
import CreatePrize from "./CreatePrize.js";

const tableRoot = document.querySelector("#csvRoot");  //table Id from index file
const csvFileInput = document.querySelector("#csvFileInput");
const createPrize = new CreatePrize(tableRoot);

//createPrize.setHeader(["ID", "Tournament Name", "Prize", "Teams", "??", "rounds"])

csvFileInput.addEventListener("change", e => {
    console.log(csvFileInput.files[0]);

    Papa.parse(csvFileInput.files[0], {
        delimiter: ",",
        skipEmptyLines: true,
        complete: results =>{
            createPrize.update(results.data.slice(0), results.data[0]);
        }
    })
});



