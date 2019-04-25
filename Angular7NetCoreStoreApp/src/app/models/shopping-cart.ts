import { Product } from './product';

export class ShoppingCart {
    customerId: string;
    products: Product[];
    totalCart: number;

    constructor() {
        this.products = Array<Product>();
        this.customerId = '';
        this.totalCart = 0;
    }
}
