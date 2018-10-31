import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ProductsAPIService {

    private url = 'products';
    private httpBody: URLSearchParams;

    constructor(private httpClient: HttpClient,
                @Inject('BASE_URL') private apiUrl: string) {
        this.httpBody = new URLSearchParams();
    }

    getProductById(id: number): Observable<Product> {
        return this.httpClient.get<Product>(`${this.apiUrl}/${this.url}/${id}`);
    }

    getAllProducts(): Observable<Product[]> {
        return this.httpClient.get<Product[]>(`${this.url}`);
    }

    addProduct(newProduct: Product): Observable<Product> {
        this.httpBody = this.prepareRequestBody(newProduct);
        return this.httpClient.post<Product>(`${this.apiUrl}/${this.url}`, this.httpBody.toString());
    }
    updateProduct(updatedProduct: Product): Observable<Product> {
        this.httpBody = this.prepareRequestBody(updatedProduct);
        return this.httpClient.put<Product>(`${this.apiUrl}/${this.url}/${updatedProduct.id}`, this.httpBody.toString());
    }

    deleteProduct(productId: number[]): Observable<Boolean> {
        productId.forEach((id) => this.httpBody.append('id[]', `${id}`));
        return this.httpClient.delete<Boolean>(`${this.apiUrl}/${this.url}/${productId}`);
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
