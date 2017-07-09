import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { DeptService } from './services/dept.service';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpModule } from '@angular/http';

import { sharedConfig } from './app.module.shared';

@NgModule({
    bootstrap: sharedConfig.bootstrap,
   
    declarations: sharedConfig.declarations,
    imports: [
       
        BrowserModule,
        BrowserAnimationsModule,
        
        HttpModule,
       
        ...sharedConfig.imports,
         
    ],
    providers: [
        DeptService,
        { provide: 'ORIGIN_URL', useValue: location.origin }
        
    ]
})
export class AppModule {
}
