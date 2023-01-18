import { useState } from "react";
import ITodo from "../api/ITodo";
import { Button, ButtonGroup, TextField } from "@mui/material";
import { useMutation, useQueryClient } from "react-query";
import { changeTodo, deleteTodo } from "../api/TodoApi";


export const Todo = (props: { key: number; todo: ITodo }) => {
  const queryClient = useQueryClient();
  const [todoValue, setTodoValue] = useState<string>(props.todo.Item);
  const [touched, setTouched] = useState<boolean>(false);

  const deleteTodoMutation = useMutation("deleteTodo", {
    mutationFn: deleteTodo,
    onSuccess: () => queryClient.invalidateQueries(["todos"]),
  });
  const updateTodoMutation = useMutation("updateTodo", {
    mutationFn: changeTodo,
    onSuccess: () => queryClient.invalidateQueries(["todos"]),
  });

  const handleDelete = (e) => {
    deleteTodoMutation.mutate(props.todo.Id);
    setTouched(false);
  };

  const handleUpdate = (e) => {
    updateTodoMutation.mutate({ Id: props.todo.Id, Item: todoValue });
    setTouched(false);
  };

  const handleCancel = (e) => {
    setTodoValue(props.todo.Item);
    setTouched(false);
  };

  const handleChange = (e) => {
    setTodoValue(e.target.value);
    setTouched(true);
  };

  return (
    <div key={props.key } className="todo-row">
      <TextField className="todo-input"
        id="outlined-basic"
        label={`ToDo - ${props.todo.Id}`}
        variant="outlined"
        value={todoValue}
        onChange={handleChange}  
        sx={{width: '90%', paddingRight:'.5em'}} 
      />
      {touched ? (
        <ButtonGroup variant="contained" aria-label="outlined button group">
          <Button color="success" onClick={handleUpdate}>
            Save
          </Button>
          <Button color="warning" onClick={handleCancel}>
            Cancel
          </Button>
        </ButtonGroup>
      ) : (
        <Button variant="contained" color="error" onClick={handleDelete}>
          Delete
        </Button>
      )}
    </div>
  );
};
