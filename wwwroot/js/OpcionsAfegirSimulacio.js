const tipus = document.querySelector("#Tipus")
const campSolar = document.querySelector("#Solar")
const campHidro = document.querySelector("#Hidro")
const campEolic = document.querySelector("#Eolic")
tipus.addEventListener("change", mostrarEntrada)
function mostrarEntrada() {
    console.log("hola")
    switch (tipus.value) {
        case "1":
            campSolar.classList.remove("amagar")
            campHidro.classList.add("amagar")
            campEolic.classList.add("amagar")
            break
        case "2":
            campSolar.classList.add("amagar")
            campHidro.classList.remove("amagar")
            campEolic.classList.add("amagar")
            break
        case "3":
            campSolar.classList.add("amagar")
            campHidro.classList.add("amagar")
            campEolic.classList.remove("amagar")
            break
        case "":
            campSolar.classList.add("amagar")
            campHidro.classList.add("amagar")
            campEolic.classList.add("amagar")
            break
    }
}