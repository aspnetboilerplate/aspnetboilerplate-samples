// create-task.component.ts
import { Component, OnInit,EventEmitter,Output } from '@angular/core';
import { CreateTaskInput, TaskServiceProxy, UserServiceProxy } from '@shared/service-proxies/service-proxies'; 
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html', 
})
export class CreateTaskComponent implements OnInit {
  task = new CreateTaskInput();
  saving = false;
  localize: any; 

  users: any[] = [];    
  @Output() onSave = new EventEmitter<any>();

  constructor(
    private _taskService: TaskServiceProxy,
    private _userService: UserServiceProxy,
    public bsModalRef: BsModalRef
  ) {

  }

  ngOnInit(): void {
    
    this._userService.getAll("",true,0,10).subscribe(data => {
      this.users = data.items;
    });
  }

  save(): void {
    this.saving = true;
    const task = new CreateTaskInput();

    this._taskService.createTask(this.task).subscribe(() => {
      this.bsModalRef.hide();
      this.onSave.emit();
    },
    () => {
      this.saving = false;
    });
  }
}
