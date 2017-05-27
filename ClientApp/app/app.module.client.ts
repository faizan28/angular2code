import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { DeptService } from './services/dept.service';
import { BrowserModule } from '@angular/platform-browser';

import { HttpModule } from '@angular/http';
import { sharedConfig } from './app.module.shared';
@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        ...sharedConfig.imports
    ],
    providers: [
        DeptService,
        { provide: 'ORIGIN_URL', useValue: location.origin }
        
    ]
})
export class AppModule {
}
