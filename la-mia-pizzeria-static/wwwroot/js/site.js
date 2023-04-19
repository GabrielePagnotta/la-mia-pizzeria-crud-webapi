const loadpizza = filter => GetPizza(filter).then(renderPizza);

const GetPizza = name => axios
    .get('/Api/Pizza', name ? { params: { name } } : {})
    .then(res => res.data);

const renderPizza = pizzas => {
    const pizzaTbody = document.querySelector("#pizza");
    pizzaTbody.innerHTML = pizzas.map(pizzaComponent).join('');
};


const pizzaComponent = pizza => `
                      <tr>    
                        <th scope="row">${pizza.id}</th>
                        <td>${pizza.name}</td>
                        <td> ${pizza.description}</td>
                        <td><img src="${pizza.image}"></td>
                        <td>${pizza.price} €</td>
                         <td>
                            <br>
                            <button onClick="createPizza(${pizza.id})" type="submit" class="btn btn-danger">
                                Crea
                            </button>
                            <br>
                            <button onClick="deletePizza(${pizza.id})" type="submit" class="btn btn-danger">
                                Cancella
                            </button>
                         </td>
                        
                    </tr>`;

function deletePizza(id) {
    axios.delete(`/Api/Pizza/${id}`)
        .then(function (response) {
            console.log(response)
        }).catch(function (error) {
            console.log(error)
        });
    location.reload()

    function createPizza(id) {
        axios.create(`/Api/Pizza/${id}`)
            .then(function (response) {
                console.log(response)
            }).catch(function (error) {
                console.log(error)
            });
        location.reload()
}