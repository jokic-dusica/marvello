import {apiCall} from '../utils/api';

const defaultUrl = '/api/comments';

const useComment = () => {
    const getAllComments = async() => {
        var response = await apiCall(defaultUrl,"get");
        if(response.isSuccess) {
            return response.data
        }
        else {
            return [];
        }
    }

    const getCommentById = async(id) => {
        var response = await apiCall(`${defaultUrl}/${id}`,"get");
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const createComment = async (newComment) => {
        var response = await apiCall(defaultUrl,"post", newComment);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const updateComment = async(comment) => {
        var response = await apiCall(`${defaultUrl}/${comment.id}`, "put", comment);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    const deleteComment = async(comment) => {
        var response = await apiCall(defaultUrl, "delete", comment);
        if(response.isSuccess) {
            return response.data;
        }
        else {
            return {}
        }
    }

    return {
        getAllComments,
        getCommentById,
        createComment,
        updateComment,
        deleteComment
    }
}

export default useComment;