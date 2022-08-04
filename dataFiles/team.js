//https://www.digitalocean.com/community/tutorials/how-to-read-and-write-csv-files-in-node-js-using-node-csv

const fs = require('fs');
const { parse } = require('csv-parse');

var parser = parse({columns: true}, function (err, records) {
    console.log(records);
});

fs.createReadStream('./TournamentModels.csv').pipe(parse({ delimiter: ",", from_line: 1 }))
.on("data", function (row) { console.log(row);
})
.on("end", function() {
    console.log("finished");
})
.on("error", function (error) {
    console.log(error.message);
});