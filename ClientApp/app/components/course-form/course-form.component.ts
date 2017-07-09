import { Component, OnInit } from '@angular/core';
import { DeptService } from './../../services/dept.service';
import { ButtonModule, GrowlModule, Message, TooltipModule} from 'primeng/primeng';
//import { ToastyService } from 'ng2-toasty';
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';
@Component({
    selector: 'CourseForm',
    templateUrl: './course-Form.Component.html',
    styleUrls: ['./course-Form.Component.css'],
   
})
export class CourseFormComponent implements OnInit {
    dept: any[];
    //teachers: any[];
    //selectedTeacher: any ={};
    teachers: any = [];
    selectCourse: any = {};
    selectedTeacher: any[];
    getselectedTeacher: any[];
    newTeacher: any = {};
    students: any = {};
    public currentCount = 0;
    public msgs: Message[] = [];
    constructor(private deptService: DeptService,
        private toastyService: ToastyService) { }
    ngOnInit() {
       
        this.deptService.getdept().subscribe(dept => {
            this.dept = dept
            console.log(dept);

        });
       
    }
  
    onTeachersChange() {
        var selectedCourse = this.selectedTeacher.find(m => m.id == this.selectCourse);
        if (selectedCourse) {
            console.log("ID", selectedCourse.id);
            this.newTeacher.id = selectedCourse.id;
        }
        else
        {
            this.newTeacher.id = [];
        }
    }

    onMakeChange() {
       
            var selectedDept = this.dept.find(m => m.id == this.teachers);
           
            if (selectedDept) {
                console.log("TEACHER", selectedDept);
              //  this.selectedTeacher = selectedDept.teachers;
                this.selectedTeacher = selectedDept.teachers;
                this.newTeacher.deptId = selectedDept.id;
                console.log(this.newTeacher);
                //console.log(this.deptvalue.tid);
            }
            else {
                this.selectedTeacher = [];
            }
        
        //this.selectedTeacher = selectedDept.teachers;
       // this.selectedTeacher = selectedDept ? selectedDept.teachers : [];
        //console.log("Teacher", this.teachers);
       
           //var selectedDept = this.dept.find(m => m.id == this.selectedTeacher);
        //console.log("TEACHER", selectedDept.teachers);
        ////this.teachers = selectedDept.teachers;
        //this.teachers = selectedDept ? selectedDept.teachers : [];
        //console.log("Teacher", this.teachers);


    }
    Submit() {
        
        console.log(this.newTeacher);
        this.deptService.create(this.newTeacher)
            .subscribe(suc => {
                this.toastyService.success({
                    title: 'Sucessfully Inserted',
                    msg: this.newTeacher.teacherName + " is Inserted",
                    showClose: true,
                    timeout: 5000,
                    theme: "bootstrap"
                })
               
                this.ngOnInit();},
            err => {
                this.toastyService.error({
                    title: 'Error Expected',
                    msg: this.newTeacher.CourseName + " is not Inserted",
                    showClose: true,
                    timeout: 5000,
                    theme: "bootstrap"
                })
            });
            //.subscribe(x => {
             
            //    this.toastyService.success({
            //        title: 'Sucessfully Inserted',
            //        msg: this.newTeacher.CourseName + " is Inserted",
            //        showClose: true,
            //        timeout: 5000,
            //        theme: "bootstrap"
            //    })
            //});

         
       
       
      
    }
  
    incrementCounter() {
        this.currentCount++;
        this.msgs.push({
            severity: 'success',
            summary: 'Infos Message',
            detail: this.currentCount.toString()
            
        });
    

        
    }
    public do(event)
    {
        //var target = event.target || event.srcElement || event.currentTarget;
        //var idAttr = target.attributes.id;
        //var value = idAttr.nodeValue;
        var id = event.target.id;
        console.log(id);
        //this.deptService.delete(id).subscribe((res) => {
        //});
     
        this.deptService.delete(id).subscribe(suc => {
                this.toastyService.success({
                    title: 'Sucessfully Deleted',
                    msg: event.target.name + " is Deleted",
                    showClose: true,
                    timeout: 5000,
                    theme: "bootstrap"
                })
                this.ngOnInit(); },
            err => {
                this.toastyService.error({
                    title: 'Error Expected',
                    msg: event.target.name + " may have any assign course",
                    showClose: true,
                    timeout: 5000,
                    theme: "bootstrap"
                })

            });
      
        ///this.deptService.delete(event.target.id);
            
        //console.log(event.target.name);
    }
    
}