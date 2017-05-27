import { Component, OnInit } from '@angular/core';
import { DeptService } from './../../services/dept.service';
@Component({
    selector: 'CourseForm',
    templateUrl: './course-Form.Component.html',
    styleUrls: ['./course-Form.Component.css'],
   
})
export class CourseFormComponent implements OnInit {
    dept: any[];
    //teachers: any[];
    //courses: any ={};
    teachers: any = {};
    courses: any[];

    constructor(private deptService: DeptService) { }
    ngOnInit() {
        this.deptService.getdept().subscribe(dept => {
            this.dept = dept
            

        });
    }
    onMakeChange() {
        var selectedDept = this.dept.find(m => m.id == this.teachers);
        console.log("TEACHER", selectedDept.teachers);
        if (selectedDept) {
            this.courses = selectedDept.teachers;
        }
        else
        {
            this.courses = [];
        }
        //this.courses = selectedDept.teachers;
       // this.courses = selectedDept ? selectedDept.teachers : [];
        //console.log("Teacher", this.teachers);
       
           //var selectedDept = this.dept.find(m => m.id == this.courses);
        //console.log("TEACHER", selectedDept.teachers);
        ////this.teachers = selectedDept.teachers;
        //this.teachers = selectedDept ? selectedDept.teachers : [];
        //console.log("Teacher", this.teachers);


    }
}