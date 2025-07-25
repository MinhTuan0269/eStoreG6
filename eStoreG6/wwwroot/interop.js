window.eStoreInterop = {
    initOwlCarousel: function () {
        if (window.$ && $('.owl-carousel').owlCarousel) {
            $('.owl-carousel').owlCarousel({
                items: 1,
                loop: true,
                margin: 10,
                nav: true
            });
        }
    }
    // Có thể thêm các hàm JS khác nếu cần
}; 