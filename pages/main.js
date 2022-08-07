import CreatePrize from "./CreatePrize.js";

const tableRoot = document.querySelector("#csvRoot");  //table Id from index file
const createPrize = new CreatePrize(tableRoot);

createPrize.update([
    [1, "positive", 99, "$100"],
    [2, "broke even", 99, 8908],
    [3, "negative", 99, "$400"]
], ["ID", "Revenue", "Profit", "Cost"])

