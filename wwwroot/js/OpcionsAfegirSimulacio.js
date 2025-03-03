const tipus = document.querySelector("#Tipus")
const entrada = document.querySelector("#Entrada")
const entradaText = document.querySelector("#EntradaText")
const enviar = document.querySelector("#Enviar")
tipus.addEventListener("change", mostrarEntrada)
function mostrarEntrada() {
    switch (tipus.value) {
        case "1":
            entrada.classList.remove("d-sm-none")
            entradaText.textContent = "Hores de Sol:"
            enviar.classList.remove("d-sm-none")
            break
        case "2":
            entrada.classList.remove("d-sm-none")
            entradaText.textContent = "Cabal d'aigua:"
            enviar.classList.remove("d-sm-none")
            break
        case "3":
            entrada.classList.remove("d-sm-none")
            entradaText.textContent = "Velocitat del vent:"
            enviar.classList.remove("d-sm-none")
            break
    }
}