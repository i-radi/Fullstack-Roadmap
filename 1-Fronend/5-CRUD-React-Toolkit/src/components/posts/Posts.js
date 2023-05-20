import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { addPost, deletePost, updatePost } from "../../redux/postsSlice";

export default function Posts() {
  const [title, setTilte] = useState("");
  const [description, setDescription] = useState("");
  const [updatedTitle, setUpdatedTilte] = useState("");
  const [updatedDescription, setUpdatedDescription] = useState("");
  const [isEdit, setEdit] = useState(false);
  const [id, setId] = useState(null);
  const posts = useSelector((state) => state.posts.items);
  const dispatch = useDispatch();
  return (
    <div>
      <div className="form">
        <input
          type="text"
          value={title}
          placeholder="Enter Post Tilte"
          onChange={(e) => setTilte(e.target.value)}
        />
        <input
          type="text"
          value={description}
          placeholder="Enter Post Description"
          onChange={(e) => setDescription(e.target.value)}
        />
        <button
          onClick={() => {
            dispatch(addPost({ id: posts.length + 1, title, description }));
            setTilte("");
            setDescription("");
          }}
        >
          Add Post
        </button>
      </div>
      <div className="posts">
        {posts.length > 0
          ? posts.map((post) => (
              <div className="post" key={post.id}>
                <h3>{post.title}</h3>
                <p>{post.description}</p>
                <button
                  onClick={() => {
                    setEdit(true);
                    setId(post.id);
                  }}
                >
                  Edit
                </button>
                <button onClick={() => dispatch(deletePost(post.id))}>
                  Delete
                </button>
                <br />
                {isEdit && id === post.id && (
                  <>
                    <input
                      type="text"
                      placeholder="updated Title"
                      value={post.updatedTitle}
                      onChange={(e) => setUpdatedTilte(e.target.value)}
                    />
                    <input
                      type="text"
                      placeholder="updated Description"
                      value={post.updatedDescription}
                      onChange={(e) => setUpdatedDescription(e.target.value)}
                    />
                    <button
                      onClick={() => {
                        dispatch(
                          updatePost({
                            id: post.id,
                            title: updatedTitle,
                            description: updatedDescription,
                          })
                        );
                        setEdit(false);
                      }}
                    >
                      Update
                    </button>
                  </>
                )}
              </div>
            ))
          : "There is no posts"}
      </div>
    </div>
  );
}
