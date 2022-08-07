export default class{
    /**
     * 
     * @param {HTMLTableElement} root The table element which will display CSV data.
     */
    constructor(root){
        this.root = root;
    }
    /**
     * 
     * @param {string[]} headerColumns List of headings to be used.
     */
    setHeader(headerColumns){
        this.root.insertAdjacentHTML("afterbegin",`
            <thead>
                ${headerColumns.map(text => `<th>${text}</th>`).join("") }

            </thead>

        `);
    }
}