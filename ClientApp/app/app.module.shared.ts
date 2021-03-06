
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { ToastyModule } from 'ng2-toasty';
import { RouterModule } from '@angular/router';

import { DeptService } from './services/dept.service';



import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CourseFormComponent } from './components/course-form/course-form.component';
import { ButtonModule, GrowlModule, TooltipModule} from 'primeng/primeng';
export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CourseFormComponent
       
    ],
    imports: [
        FormsModule,
        ButtonModule,
        GrowlModule,
        TooltipModule,
        
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'course/new', component: CourseFormComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ]),
       
    ],
    providers: [
        DeptService 
    ]
};
