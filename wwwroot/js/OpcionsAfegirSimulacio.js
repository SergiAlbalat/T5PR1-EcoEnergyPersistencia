const tipus = document.querySelector("#Tipus")
const campSolar = document.querySelector("#Solar")
const campHidro = document.querySelector("#Hidro")
const campEolic = document.querySelector("#Eolic")
const enviar = document.querySelector("#Enviar")
tipus.addEventListener("change", mostrarEntrada)
function mostrarEntrada() {
    console.log("hola")
    switch (tipus.value) {
        case "1":
            campSolar.classList.remove("d-sm-none")
            campHidro.classList.add("d-sm-none")
            campEolic.classList.add("d-sm-none")
            enviar.classList.remove("d-sm-none")
            break
        case "2":
            campSolar.classList.add("d-sm-none")
            campHidro.classList.remove("d-sm-none")
            campEolic.classList.add("d-sm-none")
            enviar.classList.remove("d-sm-none")
            break
        case "3":
            campSolar.classList.add("d-sm-none")
            campHidro.classList.add("d-sm-none")
            campEolic.classList.remove("d-sm-none")
            enviar.classList.remove("d-sm-none")
            break
        case "":
            campSolar.classList.add("d-sm-none")
            campHidro.classList.add("d-sm-none")
            campEolic.classList.add("d-sm-none")
            enviar.classList.add("d-sm-none")
            break
    }
}