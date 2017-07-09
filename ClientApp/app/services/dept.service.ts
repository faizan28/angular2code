import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
@Injectable()
export class DeptService {

    constructor(private http: Http) { }
    getdept() {
        return this.http.get('api/Depts')
            .map(res => res.json());
    }
 
    create(teacher)
    {
        return this.http.post('api/Teachers', teacher)
            .map(res => res.json());
    }
    delete(id)
    {
        return this.http.delete('api/Teachers/' + id)
            .map(res => res.json());
    }
}