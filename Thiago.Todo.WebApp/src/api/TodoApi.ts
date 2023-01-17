import axios from "axios"
import ITodo from "./ITodo"

axios.defaults.baseURL = import.meta.env["VITE_TODO_API_BASEURL"] ;
axios.defaults.headers.common['X-ApiKey'] =  import.meta.env["VITE_TODO_API_SECRET"];

export const getTodos = async () => {
    let response = await axios.get<ITodo[]>('todos');
    return response.data
  }

export const createTodo = async (todo:ITodo) => {
    let response = await axios.post<ITodo>('todos',todo);
    return response.data
  }

export const changeTodo = async (todo:ITodo) => {
    let response = await axios.put<ITodo>('todos',todo);
    return response.data
  }

export const deleteTodo = async (id:Number) => {
    await axios.delete(`todos/${id}`);
  }