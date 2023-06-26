(function () {
    const header = document.querySelector('.header');
    window.onscroll = () => {
        if(window.pageYOffset > 50){
            header.classList.add('header_active')
        }
        else{
            header.classList.remove('header_active')
        }
    }
}());


// Получаем ссылку на кнопку
let button = document.querySelector('.sup__card-button');

// Добавляем обработчик события нажатия на кнопку
button.addEventListener('click', function() {
    let bottomElement = document.querySelector('.footer');
    if (bottomElement) {
      bottomElement.scrollIntoView({ behavior: 'smooth' });
    }
  });



  
  