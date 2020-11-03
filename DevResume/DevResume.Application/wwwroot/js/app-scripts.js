init = () => {
    new fullpage('#fullpage',
        {
            anchors: ['main', 'info', 'projects', 'skills', 'experience', 'education'],
            menu: '#menu',
        });

    fullpage_api.setAllowScrolling(true);
};

destroy = () => {
    fullpage_api.destroy('all');
};

window.start = () => {
    init();
};

window.restart = () => {
    destroy();
    init();
};

window.carouselInit = () => {
    $('.gallery-slider').slick({
        arrows: false,
        dots: true,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 4000,
        speed: 500,
        fade: true,
        cssEase: 'ease',
        scrollOverflow: true
    });
};

window.moveToSection = (sectionNumber) => {
    fullpage_api.moveTo(sectionNumber);
};

window.setTitle = (title) => {
    document.title = title;
}