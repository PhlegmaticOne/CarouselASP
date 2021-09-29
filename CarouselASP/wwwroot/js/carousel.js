class CarouselCreator {
    constructor(selector, options) {
        this.options = options;
        this.selector = document.querySelector(selector);
        this.result = '';
        this.startPos = Math.floor(Math.random() * this.options.data.length);
    }
    Create() {
        this.selector.setAttribute("data-bs-interval", `${this.options.interval ? this.options.interval : 2000}`);
        this.selector.style.height = this.options.height ? this.options.height + 'px' : 'auto';
        this.selector.style.width = this.options.width ? this.options.width + 'px' : 'auto';

        if (this.options.withIndicators) {
            this.create_indicators();
        }

        this.create_inner_carousel_items();

        if (this.options.withControllers) {
            this.create_button('prev');
            this.create_button('next');
        }

        this.selector.innerHTML = this.result;
        return new bootstrap.Carousel(this.selector);
    }

    create_indicators() {
        this.result += `<div class="carousel-indicators">`;
        for (let i = 0; i < this.options.data.length; i++) {
            this.result += `<button type="button" data-bs-target="#${this.selector.id}" data-bs-slide-to="${i}" class="${i == this.startPos ? 'active' : ''}" aria-current="true"></button>`;
        }
        this.result += `</div>`;
    }

    create_inner_carousel_items() {
        this.result += `<div class="carousel-inner">`;
        let i = 0;
        for (let image of this.options.data) {
            this.result +=
                `<div class="carousel-item ${i == this.startPos ? 'active' : ''}">
                    <img src="${image.path}" class="d-block w-100" style="height:${this.options.height}px" alt="...">
                    ${this.options.withCaption ? this.create_caption(image) : ''}
                </div>
                `;
            i++;
        };
        this.result += `</div>`;
    }

    create_caption(image) {
        const g = `<div class="carousel-caption d-none d-md-block">
            <h5>${image.artist}</h5>
            <p>${image.albumName}</p>
        </div>`;
        return g;
    }

    create_button(type) {
        this.result += `
        <a href="#${this.selector.id}" class="carousel-control-${type}" role="button" data-slide="${type}">
            <span class="carousel-control-${type}-icon" aria-hidden="true"></span>
            <span class="visually-hidden">${type}</span>
        </a>
        `;
    }
}