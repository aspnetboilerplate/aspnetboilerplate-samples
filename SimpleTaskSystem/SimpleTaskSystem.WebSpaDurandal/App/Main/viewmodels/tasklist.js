define(['service!tasksystem/task'],
    function (taskService) {

        return function () {
            var that = this; //an alias of this

            that.tasks = ko.mapping.fromJS([]);  //list of tasks

            that.localize = abp.localization.getSource('SimpleTaskSystem');

            that.selectedTaskState = ko.observable(0); //'All tasks' option is selected in combobox as default

            that.activate = function () {
                that.refreshTasks();
            };

            that.refreshTasks = function () {
                abp.ui.setBusy( //Set whole page busy until getTasks complete
                    null,
                    taskService.getTasks({
                        state: that.selectedTaskState() > 0 ? that.selectedTaskState() : null
                    }).done(function(data) {
                        ko.mapping.fromJS(data.tasks, that.tasks);
                    })
                );
            };

            that.changeTaskState = function (task) {
                var newState;
                if (task.state() == 1) {
                    newState = 2;
                } else {
                    newState = 1;
                }

                taskService.updateTask({
                    taskId: task.id(),
                    state: newState
                }).done(function () {
                    task.state(newState);
                    abp.notify.info(that.localize('TaskUpdatedMessage'));
                });
            };
        };
    });