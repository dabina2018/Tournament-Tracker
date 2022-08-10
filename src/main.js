//import Papa from 'papaparse';
import CreatePrize from "./CreatePrize.js";
import CreateTeam from "./CreateTeam.js";

const tableRoot = document.querySelector("#csvRoot");  //table Id from html file
const csvFileInput = document.querySelector("#csvFileInput");
const createPrize = new CreatePrize(tableRoot);

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


//// who knows???
const express =  import("express");
const chance = import("chance").Chance();
const shuffleArray = import("shuffle-array");

const app = express();
app.use(express.static("public"));

const data = {
    headers: ["Name", "Age", "Professon", "Country"],
    rows: new Array(10).fill(undefined).map(() => {
        return [
            chance.name(),
            chance.age(),
            chance.profession(),
            chance.country({ full: true}),
        ];
    })
};

app.get("/data", (req, res) => {
    res.json({
        headers: data.headers,
        rpws: shuffleArray(data.rows),
        lastUpdated: new Date().toISOString()
    });
});

app.listen(3001, () => console.log("app is running"));
