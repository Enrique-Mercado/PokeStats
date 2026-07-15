const txtBusqueda = document.getElementById("busqueda");
const sugerencias = document.getElementById("sugerencias");
const formulario = document.getElementById("formBusqueda");
let indiceSeleccionado = -1;
let resultadoActual = [];

txtBusqueda.addEventListener("input", function () {
    console.log("pokeScripts cargado");
    const texto = txtBusqueda.value.toLowerCase();
    const limite = window.innerWidth < 768 ? 5 : 10;
    resultadoActual = listaPokemon
    .filter(pokemon => pokemon.name.startsWith(texto.trim()))
    .slice(0, limite);

    indiceSeleccionado = -1;

    sugerencias.innerHTML = ""; 

    resultadoActual.forEach(pokemon =>
        {
        const div = document.createElement("div");
        const formulario = document.getElementById("formBusqueda");
       
        div.textContent = pokemon.name;
        div.classList.add("autocomplete-item");
        div.addEventListener("click", function () {
            txtBusqueda.value = pokemon.name;
            sugerencias.innerHTML = "";
            formulario.submit();
        });
        sugerencias.appendChild(div);
    });

});

txtBusqueda.addEventListener("keydown", function(e){
    if(e.key === "ArrowDown")
    {
        e.preventDefault();

        if(indiceSeleccionado < resultadoActual.length - 1)
        {
            indiceSeleccionado++;
            actualizarSeleccion();
        }

        console.log(indiceSeleccionado);
    }
    if(e.key === "ArrowUp")
    {
        e.preventDefault();

        if(indiceSeleccionado > 0)
        {
            indiceSeleccionado--;
            actualizarSeleccion();
        }

        console.log(indiceSeleccionado);
    }
    if(e.key === "Enter")
    {
        if(indiceSeleccionado >= 0)
        {
            e.preventDefault();

            txtBusqueda.value =
                resultadoActual[indiceSeleccionado].name;

            sugerencias.innerHTML = "";
            actualizarSeleccion();
            console.log(indiceSeleccionado);

            formulario.submit();
        }
    }
    if(e.key === "Escape")
    {
        sugerencias.innerHTML = "";

        indiceSeleccionado = -1;
        console.log(indiceSeleccionado);
    }
});
function seleccionarPokemon(pokemon)
{
    txtBusqueda.value = pokemon.name;
    sugerencias.innerHTML = "";
    formulario.submit();
}

function actualizarSeleccion()
{
    const items = document.querySelectorAll(".autocomplete-item");
    items.forEach((item, index) => {

        if(index === indiceSeleccionado)
        {
            item.classList.add("active");
        }
        else
        {
            item.classList.remove("active");
        }
    });
}
document.querySelectorAll(".evolution-card")
.forEach(card=>{

    card.addEventListener("click",function(){

        txtBusqueda.value=this.dataset.pokemon;

        formulario.submit();

    });

});
/* let indiceSeleccionado = -1;
        if(e.key==="ArrowDown")
        {

        }
        if(e.key==="ArrowUp")
        {

        }
        if(e.key==="Enter")
        {
            txtBusqueda.value = pokemon.name;
            sugerencias.innerHTML = "";
            formulario.submit();
        }
*/