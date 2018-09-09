import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ProductsAPIService {

    private url = 'http://localhost:5000/api/products';
    private httpBody: URLSearchParams;

    constructor(private httpClient: HttpClient) {
        this.httpBody = new URLSearchParams();
    }

    getProductById(id: number): Observable<Product> {
        return this.httpClient.get<Product>(`${this.url}/${id}`);
    }

    getAllProducts(): Observable<Product[]> {
        return this.httpClient.get<Product[]>(`${this.url}`);
    }

    addProduct(newProduct: Product): Observable<Product> {
        this.httpBody = this.prepareRequestBody(newProduct);
        return this.httpClient.post<Product>(`${this.url}/add`, this.httpBody.toString());
    }
    updateProduct(updatedProduct: Product): Observable<Product> {
        this.httpBody = this.prepareRequestBody(updatedProduct);
        return this.httpClient.post<Product>(`${this.url}/update/${updatedProduct.id}`, this.httpBody.toString());
    }

    deleteProduct(productId: number[]): Observable<Boolean> {
        productId.forEach((id) => this.httpBody.append('id[]', `${id}`));
        return this.httpClient.post<Boolean>(`${this.url}/delete`, this.httpBody.toString());
    }

    private prepareRequestBody(product: Product): URLSearchParams {
        const dataModel = new URLSearchParams();
        for (const key in product) {
            if (product.hasOwnProperty(key)) {
                const value = product[key];
                dataModel.set(key, value);
            }
        }
        return dataModel;
    }
}

export class Product {
    id?: number;
    code: string;
    name: string;
    description?: string;
    weight: number;
    unitCost: number;
    photo: string;
    unit: string;
}
