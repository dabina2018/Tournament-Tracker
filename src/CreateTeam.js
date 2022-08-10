export default class {   
    /** 
      * Populates data table
     * @param {HTMLDivElement} root 
     */
      constructor(root){
        this.root = root;
    }   

    async function updateTable(root){
        root.querySelector(".table-refresh__button").classList.add("table-refresh__button--refreshing");

        const table = root.querySelector(".table-refresh__table");
        const response = await fetch(root.dataset.url);
        const data = await response.json();

        console.log(data);
    }

    for (const root of document.querySelectorAll(".table-refresh[data-url]")) {
        const table = document.createElement("table");
        const options = document.createElement("div");

        table.classList.add("table-refresh__table");
        options.classList.add("table-refresh__options");

        table.innerHTML = `
            <thead>
                <tr></tr>
            </thead>
            <tbody>
                <tr>
                    <td>

                    </td>
                </tr>
            </tbody>
        `;
        options.innerHTML = `
            <span class="table-fresh__label">Last Update: never</span>
            <button type="button" class="table-refresh__button">
                <i class="ion-icon">refresh</i>
            </button>            
        `;

        root.append(table, options);
        
        options.querySelector(".table-refresh__button").addEventListener("click", () => {
            updateTable(root);
        })
        updateTable(root);        
    }
}
