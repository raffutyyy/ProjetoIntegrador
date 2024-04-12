


var slideIndex = 1;

showSlides(slideIndex);

function plusSlides(n) {
  showSlides((slideIndex += n));
}

function currentSlide(n) {
  showSlides((slideIndex = n));
}

function showSlides(n) {
  var i;
  var slides = document.getElementsByClassName("myslides");
  var dots = document.getElementsByClassName("dot");

  if (n > slides.length) {
    slideIndex = 1;
  }

  if (n < 1) {
    slideIndex = slides.length;
  }

  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }

  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }

  slides[slideIndex - 1].style.display = "block";
  dots[slideIndex - 1].className += " active";
}

function validaNome()
{
    var nomeUsuario = document.getElementById("nome");
    if(nomeUsuario.value.length < 2)
    {
        alert("Teste");
        return false;
    }
    else{
        return true;
    }
}
function validaNome()
{
    var nomeUsuario = document.getElementById("nome");
    if(nomeUsuario.value.length < 2)
    {
        alert("Digite um nome válido.");
        return false;
    }
    else{
        return true;
    }
}

function validaEmail()
{
    var emailUsuario = document.getElementById("email");
    if(emailUsuario.value.length < 10)
    {
        alert("Digite um email válido.");
        document.getElementById("email").style.borderBottomColor="red";
        return false;
    }
    else{
      document.getElementById("email").style.borderBottomColor="black";
        return true;
    }
}

function validaSenha()
{
    var senhaUsuario = document.getElementById("senha");
    if(senhaUsuario.value.length < 8)
    {
        alert("Sua senha precisa ter pelos menos 8 digitos.");
       
        return false;
    }
    else{
        return true;
    }
}


