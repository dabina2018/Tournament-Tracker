const express =  require("express");
const chance = require("chance").Chance();
const shuffleArray = require("shuffle-array");

const app = express();

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
    res.send("hey beena");
});

//app.listen(3001, () => console.log("app is running"));

