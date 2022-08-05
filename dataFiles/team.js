//https://www.digitalocean.com/community/tutorials/how-to-read-and-write-csv-files-in-node-js-using-node-csv

const express = require('express');
const fs = require('fs');
const { parse } = require('csv-parse');

const app = express()

//app.METHOD(PATH, HANDLER)
app.use(express.json());
app.get('/', function (req :Request<P, ResBody, ReqBody, ReqQuery, Locals>, res: Response<ResBody,Locals> ) {
    res.json('This is a test')
})

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