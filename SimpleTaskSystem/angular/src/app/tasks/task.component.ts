import { Component, Injector, OnInit } from "@angular/core";
import {
  TaskDto,
  TaskServiceProxy,
  TaskState,
  UpdateTaskInput,
} from "@shared/service-proxies/service-proxies";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { CreateTaskComponent } from "./create-task/create-task.component";
import { PagedListingComponentBase } from "@shared/paged-listing-component-base";

@Component({
  templateUrl: "./tasks.component.html",
})
export class TasksComponent extends PagedListingComponentBase<TaskDto> implements OnInit {
 
  tasks: any[] = [];
  selectedTaskState: TaskState = 1;

  constructor(
    injector: Injector,
    private _taskService: TaskServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.list();
  }

  protected delete(entity: TaskDto): void {
  }

  createTask(): void {
    this.showCreateTaskDialog();
  }

  list(): void {
    console.log(this.selectedTaskState)
    this._taskService.getTasks(this.selectedTaskState).subscribe((data) => {
      this.tasks = data.tasks;
    })
  }

  update(task: UpdateTaskInput): void {
    const newState = task.state === 1 ? 2 : 1;

    task.state = newState;

    this._taskService.updateTask(task).subscribe(() => {
      abp.notify.info(this.l("TaskUpdatedMessage"));
      this.refresh();
    });
  }

  getTaskCountText(): string {
    return abp.utils.formatString(this.l("Xtasks"), this.tasks.length);
  }

  showCreateTaskDialog(): void {
    let createTaskDialog: BsModalRef;

    createTaskDialog = this._modalService.show(
      CreateTaskComponent, 
      {
      class: "modal-lg",
    });


    createTaskDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
