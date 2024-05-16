import os
from typing import List


def get_files(path: str) -> List[str]:
    return [
        os.path.join(path, file)
        for file in os.listdir(path)
        if os.path.isfile(os.path.join(path, file))
    ]


def create_backups(files: List[str]) -> None:
    for file in files:
        if file.endswith(".bak") or file.endswith(".py") or file.endswith(".db"):
            continue
        os.rename(file, file + ".bak")


def read_content_binary(file: str):
    with open(file, "rb") as f:
        return f.read()


def read_content(file: str):
    with open(file, "r") as f:
        return f.read()


def restore_backups(files: List[str]) -> None:
    for file in files:
        if not file.endswith(".bak"):
            continue
        file_content = read_content(file)
        new_file = file.replace(".bak", "")
        # with open(new_file, "wb") as f:
        #     f.write(file_content)
        with open(new_file, "w") as f:
            f.write(file_content)
        os.remove(file)


def remove_underline(paths):
    for path in paths:
        files: List[str] = get_files(path)
        _ = create_backups(files)
        files: List[str] = get_files(path)
        restore_backups(files)


def main():
    paths = []
    remove_underline(paths)


if __name__ == "__main__":
    main()
