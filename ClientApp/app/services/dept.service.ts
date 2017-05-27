import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
@Injectable()
export class DeptService {

    constructor(private http: Http) { }
    getdept() {
        return this.http.get('api/dept')
            .map(res => res.json());
    }
}